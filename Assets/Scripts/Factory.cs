using UnityEngine;

public abstract class Factory : MonoBehaviour
{
	public abstract IProduct Create();
}
