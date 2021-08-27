using UnityEngine;
using System.Collections;

public class camerashake : MonoBehaviour {

    public static bool canshakecamera, canhanheldcamera, cinematicmode;
    public static float intencity, handhealdintencity;
    float pnx, pny, pnz, timecounter, hhpnx, hhpny, hhpnz, hhtimecounter;
    IEnumerator shakecorroutine;
    Vector3 Thheld, Tshk;
    void Start()
    {
        intencity = 1;
        handhealdintencity = 0.05f;
    }
    void FixedUpdate () {

        if (Input.GetKey(KeyCode.F))
        {
            canshakecamera = true;
        }
        if (Input.GetKey(KeyCode.G))
        {canhanheldcamera = true;}

        if (Input.GetKey(KeyCode.H))
        { canhanheldcamera = false;}

        if (canhanheldcamera)
        { handheldcamera(); }

        if (canshakecamera)
        {shakecamera();}
        else
        {returntoorigin();}
	
	}
    void handheldcamera()
    {
        hhtimecounter += Time.deltaTime * Mathf.Pow(handhealdintencity + 1, 5);
        hhpnx = Mathf.PerlinNoise(0.1f, hhtimecounter) - 0.5f;
        hhpny = Mathf.PerlinNoise(hhtimecounter, 0.1f) - 0.5f;
        hhpnz = Mathf.PerlinNoise(hhtimecounter, hhtimecounter) - 0.5f;

        Thheld = new Vector3(hhpnx, hhpny, hhpnz) * handhealdintencity;

        transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, Thheld * Time.timeScale, Time.deltaTime);
        transform.parent.localRotation = Quaternion.Lerp(transform.parent.localRotation, Quaternion.Euler(Thheld * 100 * Time.timeScale), Time.deltaTime);
    }

    void shakecamera()
    {
        timecounter += Time.deltaTime * Mathf.Pow(intencity + 1, 2);
        pnx = Mathf.PerlinNoise(0.1f, timecounter) - 0.5f;
        pny = Mathf.PerlinNoise(timecounter, 0.1f) - 0.5f;
        pnz = Mathf.PerlinNoise(timecounter, timecounter) - 0.5f;

        Tshk = new Vector3(pnx, pny, pnz) * intencity;

        transform.localPosition = Vector3.Lerp(transform.localPosition, Tshk * Time.timeScale, Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Tshk * 100 * Time.timeScale), Time.deltaTime);

        if (shakecorroutine == null)
        {
            //print(intencity*0.3f);
            shakecorroutine = stopshake(intencity * 0.3f);
            StartCoroutine(shakecorroutine);
        }
    }

    void returntoorigin()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime/ (3*intencity));//*Time.timeScale);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, Time.deltaTime / (3*intencity));//*Time.timeScale);  
    }

    IEnumerator stopshake(float shaketimelimit)
    {
        print("started");
        yield return new WaitForSeconds(shaketimelimit);
        print("ended");
        canshakecamera = false;
        shakecorroutine = null;
    }


}
