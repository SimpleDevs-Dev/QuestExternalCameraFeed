using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Renderer))]
public class WebcamSetup : MonoBehaviour
{
    private Renderer m_renderer;

    private WebCamDevice[] m_devices;       // List of detected devices
    public WebCamDevice[] devices => m_devices;
    private WebCamTexture m_webcamTexture;  // This is created every time we select a device

    private int m_currentDeviceIndex;
    private WebCamDevice m_currentDevice;   // The current device

    [Header("=== Debug Outputs ===")]
    [SerializeField] private bool m_detectOnStart = true;
    [SerializeField] private TextMeshProUGUI m_devicesTextbox;

    private void Awake() {
        m_renderer = GetComponent<Renderer>();
        m_currentDeviceIndex = 0;
        m_currentDevice = new WebCamDevice();
    }

    private void Start() {
        if (m_detectOnStart) DetectDevices();
    }

    public void DetectDevices() {
        m_devices = WebCamTexture.devices;
        string deviceList = "No devices detected.";
        if (m_devices.Length == 0) {
            deviceList = "Detected devices:";
            for(int i = 0; i < m_devices.Length; i++) {
                string dname = m_devices[i].name;
                deviceList += $"\n{dname}";
                Debug.Log($"Detected device: {dname}");
            }
        }
        if (m_devicesTextbox != null) m_devicesTextbox.text = deviceList;
    }

    public void SelectDevice(int i) {
        if (m_webcamTexture != null) m_webcamTexture.Stop();

        m_currentDeviceIndex = i;
        m_currentDevice = m_devices[i];
        m_webcamTexture = new WebCamTexture(m_currentDevice.name);
        GetComponent<Renderer>().material.mainTexture = m_webcamTexture;
        m_webcamTexture.Play();

        float videoRatio = (float)m_webcamTexture.width / (float)m_webcamTexture.height;
        transform.localScale = new Vector3(m_webcamTexture.width, m_webcamTexture.height, 1f);
    }

    public void NextDevice() {
        if (m_devices == null) return;

        m_currentDeviceIndex++;
        if (m_currentDeviceIndex >= m_devices.Length) m_currentDeviceIndex = 0;
        SelectDevice(m_currentDeviceIndex);
    }
}
