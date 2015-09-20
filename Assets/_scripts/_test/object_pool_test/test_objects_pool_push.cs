using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

[IntegrationTest.DynamicTestAttribute( "test_objects_pool_push" )]
[IntegrationTest.SucceedWithAssertions]
public class test_objects_pool_push : MonoBehaviour {
	public Generic_object test_object;

	void Start () {
		Objects_pool.instance.push( test_object );
		Assert.AreEqual( Objects_pool.instance.container.childCount, 1 );
		Objects_pool.instance.clean();
		IntegrationTest.Pass();
	}
}
