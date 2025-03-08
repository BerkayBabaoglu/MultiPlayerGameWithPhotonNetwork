using UnityEngine;
using Photon.Pun;

public class WeaponCameraCrouch : MonoBehaviour
{
    public Transform weaponCamera;  // Player prefab i�indeki kamera
    private float defaultLocalY = 0.0181f;  // Normal duru� y�ksekli�i
    private float crouchLocalY = 0.01431f;  // E�ilme y�ksekli�i
    private float defaultLocalZ = 0.003675629f;  // Normal duru� Z konumu
    private float crouchLocalZ = 0.00551f;  // E�ilme Z konumu
    public float transitionSpeed = 10f;  // Yumu�ak ge�i� h�z�


    void Update()
    {
        if (weaponCamera == null)
        {
            Debug.LogError("WeaponCamera atanmad�! Inspector'dan ekleyin.");
            return;
        }

        bool isCrouching = Input.GetKey(KeyCode.LeftShift);
        float targetY = isCrouching ? crouchLocalY : defaultLocalY;
        float targetZ = isCrouching ? crouchLocalZ : defaultLocalZ;

        // Debug ile de�i�imin olup olmad���n� kontrol et
        Debug.Log($"isCrouching: {isCrouching}, TargetY: {targetY}, TargetZ: {targetZ}, CurrentY: {weaponCamera.localPosition.y}, CurrentZ: {weaponCamera.localPosition.z}");

        Vector3 newLocalPosition = new Vector3(
            weaponCamera.localPosition.x,
            targetY,
            targetZ
        );

        // Yumu�ak ge�i� i�in Lerp
        weaponCamera.localPosition = Vector3.Lerp(
            weaponCamera.localPosition,
            newLocalPosition,
            Time.deltaTime * transitionSpeed
        );


    }
}