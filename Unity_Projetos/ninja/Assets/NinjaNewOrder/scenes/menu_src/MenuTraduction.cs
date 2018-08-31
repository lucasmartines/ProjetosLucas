using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class MenuTraduction : MonoBehaviour {
	/// <summary>
	/// List of traductions 
	/// </summary>
	public List< ElementMenuTraduction > elements;
	public static bool isEnglish;
    public GameConfiguration gm;
    /// <summary>
	/// Only public for debug this option choose between english and portuguese
	/// </summary>

    public void ChangeGameConfigToEnglish()
    {
        GameConfiguration.gameData.isEnglish = true;
        gm.SaveConfiguration();
        gm.LoadConfiguration();

    }
    public void ChangeGameConfigToPortuguese()
    {
        GameConfiguration.gameData.isEnglish = false;
        gm.SaveConfiguration();
        gm.LoadConfiguration();

    }
	void Start(){
        gm.LoadConfiguration();
		isEnglish = GameConfiguration.gameData.isEnglish;

		elements = new List<ElementMenuTraduction> ();

		elements.Add(new ElementMenuTraduction( "Back","Voltar") ) ;
		elements.Add(new ElementMenuTraduction( "Map Menu","Mapa") ) ;
		elements.Add(new ElementMenuTraduction( "Map","Mapa") ) ;
		elements.Add(new ElementMenuTraduction( "Load Save","Salvar e Carregar") ) ;
		elements.Add(new ElementMenuTraduction( "Options","Opções") ) ;
		elements.Add(new ElementMenuTraduction( "Exit","Sair") ) ;
		elements.Add(new ElementMenuTraduction( "Traduction","Tradução") ) ;
        elements.Add(new ElementMenuTraduction("Acre Portal", "Portal Acreano"));
        elements.Add(new ElementMenuTraduction("Generical Screen", "Generica 1"));
        elements.Add(new ElementMenuTraduction("Generic Boss", "Chefao Generico"));
        elements.Add(new ElementMenuTraduction("language", "idioma"));
        elements.Add(new ElementMenuTraduction("volume", "volume"));
        elements.Add(new ElementMenuTraduction("Press Space To Confirm", "Aperte Espaço para confirmar"));
        elements.Add(new ElementMenuTraduction("Credits", "Desenvolvedores"));
        elements.Add(new ElementMenuTraduction("Screen 1", "Primeira faze"));
		elements.Add(new ElementMenuTraduction("Instructions", "Instruções"));
        elements.Add(new ElementMenuTraduction("You Win", "Vitoria"));
        elements.Add(new ElementMenuTraduction("Restart", "Reiniciar"));
        elements.Add(new ElementMenuTraduction("Come Back To Map", "Voltar Para o Mapa"));
        elements.Add(new ElementMenuTraduction("Press X button or Z key for atack", "Aperte o botão X ou a tecla Z para atacar"));
		elements.Add(new ElementMenuTraduction("For movement just use the  analogic stick or the arrows of Keyboard", "Para se mover use o analogico ou as setas do teclado"));
		elements.Add(new ElementMenuTraduction("Press R button or Left Shift key for dash", "Aperte o botão R ou a tecla Shift da esquerda para atacar"));


    }


    void Update()
    {
        isEnglish = GameConfiguration.gameData.isEnglish;

    }

    /// <summary>
    /// Get element by english traduciton
    /// </summary>
    /// <param name="EnglishElementName"></param>
    /// <returns></returns>
	public string GetElementByTraduction( string EnglishElementName){
	


	ElementMenuTraduction traduction = new ElementMenuTraduction("","");
		foreach (ElementMenuTraduction el in elements) {

			if ( el.Official == EnglishElementName) {
				traduction = el;
			}


		}


		if(  isEnglish ){
			return traduction.Official;
		}
		else{
			return traduction.TraductionPortuguese;
		}

	}


}


/// <summary>
/// Element menu traduction can be a text of button
/// for example text of pause text of play.
/// </summary>
public class ElementMenuTraduction{
	public string Official;// english translation
	public string TraductionPortuguese;

	public ElementMenuTraduction( string official, string traductionPortuguese){
		this.Official = official;
		this.TraductionPortuguese = traductionPortuguese;
	}
}