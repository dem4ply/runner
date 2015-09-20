using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

[IntegrationTest.DynamicTestAttribute( "test_objects_pool_pop" )]
[IntegrationTest.SucceedWithAssertions]
public class test_objects_pool_pop : MonoBehaviour {
	public Generic_object test_object;
	public Generic_object test_prefab_object;

	void Start () {
		Generic_object obj = Objects_pool.instance.pop( test_object );
		Assert.AreEqual( obj.gameObject.activeInHierarchy, false );
		Assert.AreEqual( obj.transform.parent, null );
		Objects_pool.instance.clean();
		obj = Objects_pool.instance.pop( test_prefab_object );
		Assert.AreEqual( obj.gameObject.activeInHierarchy, false );
		Assert.AreEqual( obj.transform.parent, null );
		Objects_pool.instance.clean();

		Objects_pool.instance.push( obj );
		Assert.AreEqual( obj.transform.parent, Objects_pool.instance.container );
		obj = Objects_pool.instance.pop( test_prefab_object );
		Assert.AreEqual( obj.gameObject.activeInHierarchy, false );
		Assert.AreEqual( obj.transform.parent, null );
		Objects_pool.instance.clean();

		IntegrationTest.Pass();
	}
}
