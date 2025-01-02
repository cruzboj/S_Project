using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    //knock back https://www.youtube.com/watch?v=RXhTD8YZnY4
    [SerializeField]
    private Rigidbody rb2d;

    [SerializeField]
    private float strength = 16, delay = 0.15f;

    public UnityEvent OnBegin, OnDone;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines ();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.forward).normalized;
        rb2d.AddForce(direction * strength , ForceMode.Impulse);
        StartCoroutine(reset());
    }

    private IEnumerator reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        OnDone?.Invoke();
    }



    //// משתנים של Knockback
    //public float KnockBackForce = 10f;   // כמות הכוח המופעלת על Knockback, ערך דיפולטי
    //public float KnockBackTime = 0.5f;   // משך זמן של Knockback
    //private float KnockBackCounter;
    //public Rigidbody _rb;
    //private HealthControler healthControler;

    //private void Start() {
    //    _rb = transform.GetComponentInParent<Rigidbody>();
    //}

    //private void Start()
    //{
    //    health
    //}
    //working but mah
    //private void OnCollisonEnter(Collision collition)
    //{
    //    Rigidbody _rb = collition.collider.GetComponent<Rigidbody>();
    //    if(_rb != null)
    //    {
    //        Vector3 direction = collition.transform.position - transform.position;
    //        direction.y = 0;

    //        _rb.AddForce(direction.normalized * KnockBackForce, ForceMode.Impulse); //ForceMode.Impulse calculate mass
    //    }
    //}

    //void Awake()
    //{
    //    // אתחול של ה-Rigidbody וה-HealthControler
    //    _rb = GetComponent<Rigidbody>();
    //    _healthControler = GetComponent<HealthControler>();
    //}

    //void Update()
    //{
    //    //// בדיקה אם ה-Knockback עדיין מופעל, ואם כן, מפחיתים את ה-counter
    //    //if (KnockBackCounter > 0)
    //    //{
    //    //    KnockBackCounter -= Time.deltaTime;
    //    //}
    //    //else
    //    //{
    //    //    // לאחר סיום ה-Knockback, אפשר לאפס את המהירות של הדמות
    //    //    _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
    //    //}
    //}
    // קריאה לפונקציה זו כאשר הדמות מקבלת מכה
    //public void Knockback(Vector3 direction)
    //{
    //    // התחלת ה-Knockback על ידי הגדרת זמן וכוח
    //    KnockBackCounter = KnockBackTime;

    //    // וידוא שה-Rigidbody מאותחל ולא null
    //    if (_rb != null)
    //    {
    //        // החלת ה-Knockback לכיוון המבוקש עם הכוח שהוגדר
    //        _rb.velocity = direction * KnockBackForce;
    //    }
    //}
}