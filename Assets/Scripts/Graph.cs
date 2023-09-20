using UnityEngine;
using static UnityEngine.Mathf;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
   [SerializeField] private Transform pointPrefab;
   [SerializeField, Range(10,100)] private int resolution = 10;
   [SerializeField] private FunctionLibrary.FunctionName function;
   Transform[] points;

   private void Awake()
   {
      points = new Transform[resolution * resolution];
      float step = 2f / resolution;
      var spawn = Vector3.zero;
      var scaleAdjustment = Vector3.one * step;
      for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
      {
         if (x == resolution)
         {
            x = 0;
            z += 1;
         }
         spawn.x = (x + 0.5f) * step - 1f;
         spawn.z = (z + 0.5f) * step - 1f;
         points[i] = Instantiate(pointPrefab, spawn, Quaternion.identity, transform);
         points[i].localScale = scaleAdjustment;

      }
   }

   private void Update()
   {
      FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
      float step = 2f / resolution;
      float v = 0.5f * step - 1f;
      for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++) {
         if (x == resolution) {
            x = 0;
            z += 1;
            v = (z + 0.5f) * step - 1f;
         }
         float u = (x + 0.5f) * step - 1f;
         points[i].localPosition = f(u, v, Time.time);
      }
   }
   
}


public static class FunctionLibrary
{
   public enum FunctionName
   {
      Wave, MultiWave, Ripple, Sphere
   }
   public delegate Vector3 Function(float u, float v, float t);

   public static Function GetFunction(FunctionName name)
   {
      return functions[(int)name];
   }

   private static readonly Function[] functions = {Wave, MultiWave, Ripple, Sphere};
   
   public static Vector3 Wave(float u, float v, float t)
   {
      Vector3 p;
      p.x = u;
      p.y = Sin(PI * (u + v + t));
      p.z = v;
      return p;
   }
   
   public static Vector3 MultiWave(float u, float v, float t)
   {
      Vector3 p;
      p.x = u;
      p.z = v;
      p.y = Sin(PI * (u + 0.5f * t));
      p.y += 0.5f * Sin(2f * PI * (v + t));
      p.y += Sin(PI * (u + v + 0.25f * t));
      p.y *= 1f / 2.5f;
      return p;
   }

   public static Vector3 Ripple(float u, float v, float t)
   {
      Vector3 p;
      float d = Sqrt(u * u + v * v);
      p.x = u;
      p.y = Sin(PI * (4f * d - t));
      p.y /= 1f + 10f * d;
      p.z = v;
      return p;
   }
   
   public static Vector3 Sphere(float u, float v, float t) 
   {
         Vector3 p;
         float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));
         float s = r * Cos(0.5f * PI * v);
         p.x = s * Sin(PI * u);
         p.y = r * Sin(0.5f * PI * v);
         p.z = s * Cos(PI * u);
         return p;
   }
}
