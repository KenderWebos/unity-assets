// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [SerializeField]
// public class Evento
// {
//     public int id;
//     public string fecha;
//     public string titulo;
//     public string descripcion;
//     public string duracion;
//     public int revisado;
//     public int estado_solicitud;
//     public string created_at;
//     public string updated_at;
//     public int id_ubicacion;
//     public int id_generador;
// }

// [SerializeField]
// public class EventoList
// {
//     public List<Evento> eventos;
// }

// public class ApiTest : MonoBehaviour
// {

//     [SerializeField]
//     // private string baseUrl = "https://kevincampos.cl/api/";
//     private string baseUrl = "http://127.0.0.1:8000/api/";

//     // Método para hacer ping
//     public void Ping()
//     {
//         string url = baseUrl + "ping";
//         ApiHandler.Instance.GetRequest(url, HandlePingResponse);
//     }

//     public void Events()
//     {
//         string url = baseUrl + "v1/evento";
//         ApiHandler.Instance.GetRequest(url, HandlePingResponse);
//     }

//     private void HandlePingResponse(string response)
//     {
//         if (response != null)
//         {
//             ApiResponse apiResponse = JsonUtility.FromJson<ApiResponse>(response);
//             print(apiResponse.message);
//         }
//         else
//         {
//             Debug.LogError("Failed to get response.");
//         }
//     }

//     public void Start(){
//         print("> iniciando consulta a la api <");
//         Ping();
//         Events();
//     }
// }
