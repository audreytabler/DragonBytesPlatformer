using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class StatManager : MonoBehaviour
{
    public static int changeVal = 0;

    public static int grade = 80;
    public static int energy = 70;
    public static int social = 50;
    public static int fun = 50;

    VisualElement gradebar;
    VisualElement energybar;
    VisualElement socialbar;
    VisualElement funbar;
    Label gradeLetter;



    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;
        VisualElement box = root.Q<VisualElement>("progressBars");

        gradeLetter = box.Q<Label>("GradeLetter");

        gradebar = box.Q<VisualElement>("grade_bar");
        energybar = box.Q<VisualElement>("energy_bar");
        socialbar = box.Q<VisualElement>("social_bar");
        funbar = box.Q<VisualElement>("fun_bar");

    }

    public void updateGrade()
    {
        if (grade + changeVal >= 100)
        {
            grade = 100;
            gradebar.style.width = grade;
            return;
        }
        else if (grade + changeVal <= 0)
        {
            grade = 0;
            gradebar.style.width = grade;
            //endGame("expelled")
            return;
        }

        grade += changeVal;
        gradebar.style.width = grade;

        if (grade > 89)
        {
            gradeLetter.text = "A";
            //gradebar.style.backgroundColor //ColorTranslator.FromHtml("#7DFF52");
            gradebar.style.backgroundColor = Color.green; //Color.Red;
        }
        else if (grade <= 89 && grade > 70)
        {
            gradeLetter.text = "B";
            gradebar.style.backgroundColor = Color.Lerp(Color.green, Color.yellow, 0.5f);
        }
        else if (grade <= 70 && grade > 59)
        {
            gradeLetter.text = "C";
            gradebar.style.backgroundColor = Color.yellow;
        }

        else if (grade <= 59 && grade > 40)
        {
            gradeLetter.text = "D";
            gradebar.style.backgroundColor = Color.red;
        }
        else
            gradeLetter.text = "F";


    }

    public void updateEnergy()
    {
        if (energy + changeVal >= 100)
        {
            energy = 100;
            energybar.style.width = grade;
            return;
        }
        else if (grade + changeVal <= 0)
        {
            grade = 0;
            energybar.style.width = grade;
            //endGame("expelled")
            return;
        }

        energy += changeVal;
        energybar.style.width = grade;
    }

    public void updateFun()
    {
        if (fun + changeVal >= 100)
        {
            fun = 100;
            funbar.style.width = grade;
            return;
        }
        else if (fun + changeVal <= 0)
        {
            fun = 0;
            funbar.style.width = grade;
            //endGame("expelled")
            return;
        }

        fun += changeVal;
        funbar.style.width = grade;
    }

    public void updateSocial()
    {
        if (social + changeVal >= 100)
        {
            social = 100;
            socialbar.style.width = grade;
            return;
        }
        else if (social + changeVal <= 0)
        {
            social = 0;
            socialbar.style.width = grade;
            //endGame("expelled")
            return;
        }

        social += changeVal;
        socialbar.style.width = grade;
    }
}