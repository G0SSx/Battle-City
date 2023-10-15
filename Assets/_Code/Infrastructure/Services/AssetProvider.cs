using UnityEngine;

public static class AssetProvider {
	public static TType Load<TType>(string path) where TType : Object => Resources.Load<TType>(path);
	public static GameObject Load(string path) => Resources.Load<GameObject>(path);
	public static GameObject[] LoadAll(string path) => Resources.LoadAll<GameObject>(path);
	public static TType[] LoadAll<TType>(string path) where TType : Object => Resources.LoadAll<TType>(path);
}