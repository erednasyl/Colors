using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public string showableText;
    public TMP_Text text;

    public void ChangeTxt(){
        text.text = showableText;
    }

    public void NotanText(){
        showableText = "Termo japonês que essencialmente significa a relação entre tons claros e escuros. As interpretações para esse termo são várias, mas nessa obra consideramos que notan carrega a essência pura dos objetos, sem envolver cinzas ou cores, apenas a informação se é escuro ou claro!";
    }

    public void VisaoNotanText(){
        showableText = "Os afetados por essa visão veem tudo em preto e branco, no sentido mais cru possível. Não existem cinzas, nem sombras. Apenas objetos escuros ou claros!";
    }

    public void Sobrexpo(){
        showableText = "Posicionar um objeto sobre o outro.";
    }

    public void none(){
        showableText = "Explore o jogo para encontrar novos termos!";
    }
}
