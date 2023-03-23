import React, {useState} from 'react';
import {createFactories} from "../../http/ItemAPI";
import Warning from "../tools/Warning";


const CreateFactory = ({setActive}) => {
    const[factoryName,setFactoryName] = useState()
    const[factoryAddress,setFactoryAddress] = useState("Адреса не вказана")
    const[errDivFactory,setErrDivVisibleFactory] = useState(false)


    const addFactory=()=>    {
        createFactories({
            name:factoryName,
            address:factoryAddress,
            img:"defaultFac.png"}).then(data=>{
            setFactoryName('')
            setFactoryAddress('')
            setActive(false)
            document.body.style.overflowY = "scroll"
        })

    }
    return (

            <form encType="multipart/form-data">
                <h1>Введіть назву виробника<span style={{color:"red"}}>*</span></h1>
                <input type="text" value={factoryName} style={factoryName==""||factoryName==null? {border:"5px solid red"}: {borderColor:"blue"}}
                       onChange={e=>setFactoryName(e.target.value)}/>
                <h1>Введіть адресу виробника<span style={{color:"red"}}>*</span></h1>
                <input type="text" value={factoryAddress} style={ {borderColor:"blue"}}
                       onChange={e=>setFactoryAddress(e.target.value)}/>
                {errDivFactory ?
                    <Warning>Треба заповнити усі обов'язкові дані</Warning>
                    : <Warning>Для додання предмету заповніть обов'язкові поля,які позначені *</Warning>}
                <button className='addbtn' onClick={(e)=>{
                    if(factoryName){
                        e.preventDefault()
                        addFactory()
                        setErrDivVisibleFactory(false)}
                    e.preventDefault()
                    setErrDivVisibleFactory(true) }}>Add</button>


            </form>

    );
};

export default CreateFactory;