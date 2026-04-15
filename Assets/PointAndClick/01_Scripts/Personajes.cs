using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Personaje
{
    public string nombre;
    public int edad;
    public string ocupacion;
    public string historia;
    public string personalidad;
    public string habilidades;
}
public class Personajes : MonoBehaviour
{
    public List<Personaje> personajes = new List<Personaje>();
    
}
   