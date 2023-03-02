import axios from "axios";
import { useParams } from "react-router-dom";
import { variables } from "../utils/consts";



export const fetchTypes= async()=>{
    const{data} = await axios.get(variables.APP_URL+'type')
    return data
}

export const createTypes= async(type)=>{
    const{data} = await axios.post(variables.APP_URL+'type',type)
    return data
}

export const fetchFactories= async()=>{
    const{data} = await axios.get(variables.APP_URL+'factory')
    return data
}
export const createFactories= async(factory)=>{
    const{data} = await axios.post(variables.APP_URL+'factory',factory)
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
    const{data} = await axios.post(variables.APP_URL+'product',item)
    return data
}

export const postImage= async(img)=>{
    const{data} = await axios.post(variables.APP_URL+'product/SaveFile',img)
    return data
}

export const fetchItemsById= async(id)=>{
    const{data} = await axios.get(variables.APP_URL+'product/'+id)
    return data
}

export const fetchTypeById= async(id)=>{
    const{data} = await axios.get(variables.APP_URL+'typeitem/'+id)
    return data
}

export const fetchFactoryById= async(id)=>{
    const{data} = await axios.get(variables.APP_URL+'factory/'+id)
    return data
}