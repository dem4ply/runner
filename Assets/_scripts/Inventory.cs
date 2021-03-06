﻿using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	/// <summary>
	/// contenedor fisico de los gameobjects de los items
	/// </summary>
	public Transform container;
	
	/// <summary>
	/// contenedor de los items
	/// </summary>
	public Dictionary<Item, List<Item>> _container;
	
	/// <summary>
	/// agrega un item al contenedor
	/// </summary>
	/// <param name="item">item que se agregara</param>
	/// <param name="amount">cantidad que se agregara</param>
	public void add_item(Item item, int amount) {
		List<Item> list_items = new List<Item>();
		if (!_container.TryGetValue(item, out list_items)) {
			list_items = new List<Item>();
			_container.Add(item, list_items);
		}
		if (item.is_stackable)
			foreach (Item i in list_items) {
				amount = i.add_amount(amount);
				if (amount == 0)
					break;
			}
		
		while (amount > 0) {
			Item item_tmp = clone_item(item);
			amount = item_tmp.add_amount(amount);
			list_items.Add(item_tmp);
		}
	}
	
	/// <summary>
	/// funcion que se ejecuta antes de agregar un item al contenedor
	/// pensado para que los hijos(herencia) de Inventory puedan analizar los items
	/// antes de ser agregados
	/// </summary>
	/// <param name="item">item que se analizara</param>
	/// <param name="amount">cantidad de items que se agregaran</param>
	protected virtual void before_add(Item item, int amount) {}
	
    /// <summary>
    /// clona un item usando el snippet de inventory
    /// </summary>
    /// <param name="item">item a clonar no se modifica</param>
    /// <returns>item clonado</returns>
	protected virtual Item clone_item(Item item){
		Item result;
		helper.inventory.clone_item(item, out result);
		result.transform.parent = container;
		return result;
	}
	
	protected virtual void Awake(){
		Debug.Log("Awake");
		_container = new Dictionary<Item, List<Item>>();
		if (container == null)
			container = this.transform;
	}
	
	protected virtual void Start(){
		Debug.Log("Start");
	}
	
	protected virtual void Update() {
		Debug.Log("Update");
	}
	
}
