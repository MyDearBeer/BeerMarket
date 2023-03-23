import axios from "axios";
import { useParams } from "react-router-dom";
import { variables } from "../utils/consts";
import {$authUser} from "./index";



export const fetchTypes= async()=>{
    const{data} = await axios.get(variables.APP_URL+'type')
    return data
}

export const createTypes= async(type)=>{
    const{data} = await $authUser.post('type',type)
    return data
}



export const fetchFactories= async()=>{
    const{data} = await axios.get(variables.APP_URL+'factory')
    return data
}
export const createFactories= async(factory)=>{
    const{data} = await $authUser.post('factory',factory)
    return data
}


export const fetchItems= async(typeId,factoryId,page,limit)=>{
    const{data} = await axios.get(variables.APP_URL+'product',{params :{
        typeId,factoryId,page,limit
    }

    })
    return data
}

export const createItems= async(item)=>{
    const{data} = await $authUser.post('product',item)
    return data
}

export const deleteItems= async(id)=>{
    const{data} = await $authUser.delete('product/' + id)
    return data
}

export const postImage= async(img)=>{
    const{data} = await $authUser.post('product/SaveFile',img)
    return data
}

export const fetchItemsById= async(id)=>{
    const{data} = await axios.get(variables.APP_URL+'product/'+id)
    return data
}

export const fetchBasketItem = async()=>{
    const{data} = await $authUser.get('basket')
    return data
}

export const postBasketItem = async(basketItem)=>{
    const{data} = await $authUser.post('basket',basketItem)
    return data
}

export const deleteBasketItem = async(id)=>{
    const{data} = await $authUser.delete('basket/' + id)
    return data
}