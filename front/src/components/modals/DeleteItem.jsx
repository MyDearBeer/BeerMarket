import React, {useEffect} from 'react';
import { useState } from 'react';
import { useContext } from 'react';
import {deleteItems, fetchItems} from "../../http/ItemAPI";
import Warning from "../tools/Warning";
import {Context} from "../../index";


const DeleteItem = ({setActive}) => {
    const {product}=useContext(Context)
    const[itemId,setItemId] = useState()
    const[errDivType,setErrDivVisibleType] = useState(false)
    const deleteProduct=()=>    {
        deleteItems(itemId).then(data=>{
            setItemId('')
            setActive(false)
            document.body.style.overflowY = "scroll"})
            .catch(err=>
                console.log(err.message))
    }

    useEffect(() => {
        fetchItems().then(data => {
            product.setItem(data.products)
            //product.setTotalCount(data.length)
        })
    }, [product.item])


    return (

        <form encType="multipart/form-data">
            <h1>Введіть назву товару<span style={{color:"red"}}>*</span></h1>
            <select className='optionsList' style={itemId==null? {border:"5px solid red"}: {borderColor:"blue"}}
                    onChange={(e)=>{setItemId(e.target.value)
                console.log(e.target.value)}}>
                {product.item.map(item=>
                    <option key={item.id} value={item.id}>{item.name}</option>

                )}
            </select>
            {errDivType ?
                <Warning>Треба заповнити усі обов'язкові дані</Warning>
                : <Warning>Для додання предмету заповніть обов'язкові поля,які позначені *</Warning>}
            {itemId?
                <button className='addbtn' onClick={ (e)=>{
                    e.preventDefault()
                    deleteProduct()
                    product.setItem(product.Item.filter((item) => item.id !== itemId))
                    setErrDivVisibleType(false)}}>Delete</button>
                :   <button className='addbtn'
                            onClick={(e)=>{
                                setErrDivVisibleType(true)
                                e.preventDefault()}}>Delete</button>}

        </form>


    );
};

export default DeleteItem;