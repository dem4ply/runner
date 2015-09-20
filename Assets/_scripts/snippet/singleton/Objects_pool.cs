using UnityEngine;
using System.Collections.Generic;

public class Objects_pool : Singleton<Objects_pool> {
	public Transform container;

	protected Objects_pool() {
	}

	protected Dictionary<Generic_object, Stack<Generic_object>> _dict;

	/// <summary>
	/// regresa un objeto del containr, si no hay uno disponible instanciara uno
	/// </summary>
	/// <param name="key">objeto que se quiere obtener</param>
	/// <returns>instancia del objeto que se quiere obtener, siemrpe esta inactivo</returns>
	public virtual Generic_object pop( Generic_object key ) {
		Generic_object result = null;
		if ( _dict.ContainsKey( key ) ) {
			Stack<Generic_object> stack = _dict[key];
			if ( stack.Count > 0 )
				result = stack.Pop();
		}
		if ( result == null ) {
			result = helper.instantiate.inactive._<Generic_object>( key );
		}
		else
			result.transform.parent = null;
		return result;
	}

	/// <summary>
	/// inserta un objeto a la lista de la pisina basado
	/// </summary>
	/// <param name="value">objeto que se quiere agregar a la picina</param>
	public virtual void push( Generic_object value ) {
		_move_to_container( value );
		if ( _dict.ContainsKey( value ) )
			_dict[value].Push( value );
		else {
			Stack<Generic_object> stack_tmp = new Stack<Generic_object>();
			stack_tmp.Push( value );
			_dict.Add( value, stack_tmp );
		}
	}

	/// <summary>
	/// prepara una cantidad de objetos
	/// </summary>
	/// <param name="obj">objeto que se quiere preparar en la picina</param>
	/// <param name="amount">cantidad que se desea preparar</param>
	public virtual void prepare_objects( Generic_object obj, int amount ) {
		Stack<Generic_object> stack;
		if ( _dict.ContainsKey( obj ) )
			stack = _dict[obj];
		else
			stack = new Stack<Generic_object>( amount );
		for ( ; amount > 0; --amount ) {
			Generic_object obj_tmp = helper.instantiate.inactive.parent<Generic_object>( obj, container );
			stack.Push( obj_tmp );
		}
		_dict.Add( obj, stack );
	}

	/// <summary>
	/// mueve el objeto al contendor y lo desabilita
	/// </summary>
	/// <param name="obj">objeto a mover al conetenedor</param>
	protected virtual void _move_to_container( Generic_object obj ) {
		try {
			obj.transform.parent = container;
			obj.gameObject.SetActive( false );
		}
		catch ( System.Exception e ) {
			helper.instantiate.inactive.parent( obj, container );
			Debug.Log( e );
		}

	}

	/// <summary>
	/// limpia el contenedor y el dicionario
	/// </summary>
	public virtual void clean() {
		for ( int i = 0; i < container.childCount; ++i ) {
			Destroy( container.GetChild( i ).gameObject );
		}
		foreach ( KeyValuePair<Generic_object, Stack<Generic_object>> items in _dict ) {
			items.Value.Clear();
		}
	}

	/// <summary>
	/// inicializa el dicionario pra los objetos y asigna el contendor si no se escojio uno
	/// </summary>
	protected virtual void Awake() {
		_dict = new Dictionary<Generic_object, Stack<Generic_object>>();
		if ( !container )
			container = this.transform;
		try {
		}
		catch ( System.Exception e ) {
			Debug.LogError( e );
		}
	}
}

