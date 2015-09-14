using UnityEngine;
using System.Collections.Generic;

public class Objects_pool : Singleton<Objects_pool> {
	public Transform container;
	
	protected Objects_pool(){}
	
	protected Dictionary<Generic_object, Stack<Generic_object>> _dict;
	
	
	public virtual Generic_object pop(Generic_object key){
		Generic_object result = null;
		if (_dict.ContainsKey(key)) {
			Stack<Generic_object> stack = _dict[key];
			if (stack.Count > 0)
				result = stack.Pop();
		}
		if (result == null){
			result = helper.instantiate.inactive._<Generic_object>(key);
		}
		else
			result.transform.parent = null;
		return result;
	}
	
	public virtual void push(Generic_object value){
		move_to_container(value);
		if (_dict.ContainsKey(value))
			_dict[value].Push(value);
		else {
			Stack<Generic_object> stack_tmp = new Stack<Generic_object>();
			stack_tmp.Push(value);
			_dict.Add(value ,stack_tmp);
		}
	}
	
	public virtual void prepare_objects(Generic_object obj, int amount){
		Stack<Generic_object> stack;
		if (_dict.ContainsKey(obj))
			stack = _dict[obj];
		else
			stack = new Stack<Generic_object>(amount);
		for (; amount > 0; --amount){
			Generic_object obj_tmp = helper.instantiate.inactive.parent<Generic_object>(obj, container);
			stack.Push(obj_tmp);
		}
		_dict.Add(obj, stack);
	}
	
	
	protected virtual void move_to_container(Generic_object obj){
		obj.transform.parent = container;
		obj.gameObject.SetActive(false);
	}
	
	protected virtual void Awake(){
		_dict = new Dictionary<Generic_object, Stack<Generic_object>>();
		if (!container)
			container = this.transform;
		try {
		}
		catch(System.Exception e) {
			Debug.LogError(e);
		}
	}
}

