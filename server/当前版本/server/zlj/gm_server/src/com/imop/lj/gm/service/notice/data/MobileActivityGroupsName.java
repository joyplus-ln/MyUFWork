package com.imop.lj.gm.service.notice.data;

public class MobileActivityGroupsName {
	private String name ;
	private int id;
	
	public MobileActivityGroupsName(){}
	
	public MobileActivityGroupsName(String name,int id){
		this.id = id;
		this.name = name;
	}
	
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	
	
}
