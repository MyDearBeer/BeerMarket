import React,{useState} from 'react'
import {createTypes} from "../../http/ItemAPI";
import Warning from "../tools/Warning";

const CreateType = ({setActive}) => {
    const[type,setType] = useState()
    const[errDivType,setErrDivVisibleType] = useState(false)
    const addType=()=>    {
        createTypes({name:type}).then(data=>{
            setType('')
        setActive(false)
            document.body.style.overflowY = "scroll"})
            .catch(err=>
            console.log(err.message))
    }
    return (

            <form encType="multipart/form-data">
                <h1>Введіть назву категорії<span style={{color:"red"}}>*</span></h1>
                <input type="text" value={type} style={type==""||type==null? {border:"5px solid red"}: {borderColor:"blue"}}
                       onChange={e=>setType(e.target.value)}/>
                {errDivType ?
                    <Warning>Треба заповнити усі обов'язкові дані</Warning>
                    : <Warning>Для додання предмету заповніть обов'язкові поля,які позначені *</Warning>}
                {type?
                    <button className='addbtn' onClick={ (e)=>{
                        e.preventDefault()
                        addType()
                        setErrDivVisibleType(false)}}>Add</button>
                    :   <button className='addbtn'
                                onClick={(e)=>{
                                    setErrDivVisibleType(true)
                                    e.preventDefault()}}>Add</button>}

            </form>

    );
};

export default CreateType;