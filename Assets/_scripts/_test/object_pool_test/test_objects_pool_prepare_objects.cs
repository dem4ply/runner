using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

[IntegrationTest.DynamicTestAttribute( "test_objects_pool_prepare_objects" )]
[IntegrationTest.SucceedWithAssertions]
public class test_objects_pool_prepare_objects : MonoBehaviour {
	public Generic_object test_object;
	public Generic_object test_prefab;

	void Start () {
		Objects_pool.instance.prepare_objects( test_object, 10 );
		Assert.AreEqual( Objects_pool.instance.container.childCount, 10 );
		Objects_pool.instance.clean();
		Objects_pool.instance.prepare_objects( test_prefab, 10 );
		Assert.AreEqual( Objects_pool.instance.container.childCount, 20 );
		Objects_pool.instance.clean();
		IntegrationTest.Pass();
	}
}
