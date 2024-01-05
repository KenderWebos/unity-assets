// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class npc : MonoBehaviour
// {
//     public string name;
//     public bool mainTaskCompleted = false;

//     public GameObject txt_mainPanel;
//     public GameObject txtOutput;

//     public GameObject uiFeedback;


//     public enum characters
//     {
//         infinity,
//         roboto,
//         cubu,
//         juan,
//     }

//     private void OnTriggerEnter(Collider obj)
//     {
//         if (obj.tag.Equals("Player"))
//         {

//             if (!mainTaskCompleted)
//             {
//                 switch (this.name)
//                 {
//                     case "infinity":
//                         txtOutput.GetComponent<Text>().text = "Holaa!, mi nombre es infinity. \nComo?, quieres llevarte mi estrella?...\nBien no hay problema nos vemos en la celebracion.";
//                         GameObject.Find("character_infinity").GetComponent<npc>().mainTaskCompleted = true;
//                         GameObject.Find("character_infinity").GetComponent<npc>().uiFeedback.transform.GetChild(0).gameObject.SetActive(true);

//                         break;
//                     case "roboto":
//                         txtOutput.GetComponent<Text>().text = "TEXTO GENERICO DE UN ROBOT";
                        
//                         break;
//                     case "cubu":
//                         txtOutput.GetComponent<Text>().text = "Cuanto tiempo sin verte!. \nNecesito que me ayudes con las cosechas y te dare mi arbol de navidad.";

//                         break;

//                     case "juan":
//                         txtOutput.GetComponent<Text>().text = "Hola me llamo juanito y soy el mas choro.";

//                         break;
//                     default:
//                         break;
//                 }

//                 if (uiFeedback!=null)
//                 {
//                     uiFeedback.GetComponent<Image>().color = Color.white;
//                     SoundManager.instance.MakeSound(SoundManager.SoundType.talking);
//                 }

//             }else if(mainTaskCompleted)
//             {
//                 switch (this.name)
//                 {
//                     case "infinity":
//                         txtOutput.GetComponent<Text>().text = "Genial!.";

//                         break;
//                     case "roboto":
//                         txtOutput.GetComponent<Text>().text = "No era necesario hacerlo bailando pero tienes la idea.";

//                         break;
//                     case "cubu":
//                         txtOutput.GetComponent<Text>().text = "Gracias amigo.";

//                         break;
//                     default:
//                         break;
//                 }
//             }

//             txt_mainPanel.SetActive(true);

//         }

//     }

//     private void OnTriggerExit(Collider obj)
//     {
//         if (obj.tag.Equals("Player"))
//         {

//             txt_mainPanel.SetActive(false);

//         }

//     }
// }
