using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class StatHandler : MonoBehaviour
{
    
    private int healingFactor = 100;
    private int healp = 1;
    private int cripplingStrikep = 1;
    private int parasitep = 1;
    private int defenseAurap = 1;
    private int vitalityDrainp = 1;
    private int arcaneSlashp = 1;
    private int pts = 25;
    public Button myButton;
    public TMP_Text pt;
    public TMP_Text t1;
    public TMP_Text t2;
    public TMP_Text t3;
    public TMP_Text t4;
    public TMP_Text t5;
    public TMP_Text t6;

    public void nextt() {
        SceneManager.LoadScene("Game");
    }
    private bool havePt() {
        return pts > 0;
    }
    void Update()
    {
        pt.text = (31-healp-cripplingStrikep-parasitep-defenseAurap-vitalityDrainp-arcaneSlashp).ToString();
    }
    public void inchealp() {
        if(!havePt() || healp >= 9) return;
        --pts;
        healp++;
        t1.text = healp.ToString();
    }
    public void dechealp() {
        if(healp <= 1) return;
        ++pts;
        healp--;
        t1.text = healp.ToString();
    }
    public void inccripplingStrikep() {
        if(!havePt() || cripplingStrikep >= 9) return;
        --pts;
        cripplingStrikep++;
        t2.text = cripplingStrikep.ToString();
    }
    public void deccripplingStrikep() {
        if(cripplingStrikep <= 1) return;
        ++pts;
        cripplingStrikep--;
        t2.text = cripplingStrikep.ToString();
    }
    public void incparasitep() {
        if(!havePt() || parasitep >= 9) return;
        --pts;
        parasitep++;
        t3.text = parasitep.ToString();
    }
    public void decparasitep() {
        if(parasitep <= 1) return;
        ++pts;
        parasitep--;
        t3.text = parasitep.ToString();
    }
    public void incdefenseAurap() {
        if(!havePt() || defenseAurap >= 9) return;
        --pts;
        defenseAurap++;
        t4.text = defenseAurap.ToString();
    }
    public void decdefenseAurap() {
        if(defenseAurap <= 1) return;
        ++pts;
        defenseAurap--;
        t4.text = defenseAurap.ToString();
    }
    public void incvitalityDrainp() {
        if(!havePt() || vitalityDrainp >= 9) return;
        --pts;
        vitalityDrainp++;
        t5.text = vitalityDrainp.ToString();
    }
    public void decvitalityDrainp() {
        if(vitalityDrainp <= 1) return;
        ++pts;
        vitalityDrainp--;
        t5.text = vitalityDrainp.ToString();
    }
    public void incarcaneSlashp() {
        if(!havePt() || arcaneSlashp >= 9) return;
        --pts;
        arcaneSlashp++;
        t6.text = arcaneSlashp.ToString();
    }
    public void decarcaneSlashp() {
        if(arcaneSlashp <= 1) return;
        ++pts;
        arcaneSlashp--;
        t6.text = arcaneSlashp.ToString();
    }
}
