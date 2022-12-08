import React from 'react';
import { useState } from 'react';
import { useContext } from 'react';
import { Context } from '../..';
import { createItems, postImage } from '../../http/ItemAPI';


const CreateItem = ({modalItemVisible,setActive}) => {
    const {product}=useContext(Context)
    const[info,setInfo]=useState([])
    const[typeID,setTypeId] = useState()
    const[factoryID,setFactoryId] = useState()
    const[name,setName] = useState()
    const[rate,setRate] = useState(0)
    const[price,setPrice] = useState(0)
    const[img,setImg] = useState()
    const[imgName,setImgName] = useState()
    const[desc,setDesc] = useState()
    const[errDiv,setErrDivVisible] = useState(false)



  const addItem=(e)=>    {
    console.log(product.selectedFactory)

createItems({name:name,
  rating:rate,
  price:price,
  img:imgName /* ? img.name: "defaultItem.png" */,
  factoryId:factoryID,
  typeId:typeID,
  description:desc,
  itemInfo:info})
.then(data=>setActive(false)) 

if(img){
const formData = new FormData()
formData.append("file",img,img.name)
postImage(formData).then(data=>setActive(false)) 
}
  }

    const addInfo=()=>{
        setInfo([...info,{title:'',value:'',number:Date.now()}])
    }
    const removeInfo=(number)=>{
        setInfo(info.filter(info=>info.number!==number))
    }

const changeInfo=(key,value,number)=>{
setInfo(info.map(i=>i.number===number?{...i,[key]:value}:i))
}

    const selectFile=(e)=>{
setImg(e.target.files[0])
setImgName(e.target.files[0].name)
    }

    return (
        


          <form encType="multipart/form-data">
             <h1>Введіть назву виробу <span style={{color:"red"}}>*</span></h1>
             <input type="text" value={name} style={name==""|| name==null? {border:"3px solid red"}: {border:"blue"}} onChange={(e)=>setName(e.target.value)}/>
           
            <h1>Виберіть тип виробу<span style={{color:"red"}}>*</span></h1>
            <select className='optionsList' value={typeID} style={typeID==null? {border:"5px solid red"}: {border:"blue"}} onChange={(e)=>{setTypeId(e.target.value)
            console.log((e.target.value))}}>
              {product.type.map(type=>
                    <option key={type.id} value={type.id} 
                    >{type.name}</option>
                 
              )}
                </select>
                <h1>Введіть назву виробника<span style={{color:"red"}}>*</span></h1>
            <select className='optionsList' style={factoryID==null? {border:"5px solid red"}: {border:"blue"}} onChange={(e)=>{setFactoryId(e.target.value)
            console.log(e.target.value)}}>
            {product.factory.map(factory=>
                    <option key={factory.id} value={factory.id}>{factory.name}</option>
                 
              )}
                </select>
                <h1>Введіть рейтинг</h1>
            <input type="number" step="0.1" min="0" max="5" value={rate}  onChange={(e)=>setRate(Number(e.target.value))}/>
            <h1>Введіть ціну за 1 од.</h1>
            <input type="number" min="0" value={price} onChange={(e)=>setPrice(Number(e.target.value))}/>
            <h1>Завантажте картинку</h1>
            <input className='fileInput' type="file" onChange={selectFile}/>
            <h1>Опис товару</h1>
            <textarea  className='description' style={{fontSize:"50px"}} placeholder="Опис" value={desc} onChange={(e)=>setDesc(e.target.value)}></textarea> 
            
            <button className='addbtn' onClick={(e)=>{addInfo()
           e.preventDefault() 
           console.log(info.number)}}>Додати характеристику</button><br/>
            {info.map(info=>
            <div key={info.number}>
                  <input style={{width:"40vw", margin:"20px"}} type="text" placeholder='Характеристика' value={info.title} onChange={(e)=>changeInfo('title',e.target.value,info.number)}/>
                  <input style={{width:"25vw"}} type="text" placeholder='Значення' value={info.description} onChange={(e)=>changeInfo('value',e.target.value,info.number)}/>
                  <button className='closeBtn' onClick={(e)=>{
                    e.preventDefault()
                    removeInfo(info.number)}}>Видалити</button>
            </div>)
            
            }


          {errDiv ?
          <div className='notFullInfo'>Треба заповнити усі обов'язкові дані</div>
         : <div className='notFullInfo'>Для додання предмету заповніть обов'язкові поля,які позначені *</div>}
         
      
            <button className='addbtn' onClick={(e)=>{
              
              if(name&&factoryID&&typeID){
              // product.item.map(i=>{
              //   if(name==i.name){
              //   setErrDivVisible(true) 
              //   console.log("dfuck")
              //   }
              // console.log(i.name)
              addItem()
              setErrDivVisible(false) 
                
              // }
              }
            
              
              e.preventDefault()
              
              setErrDivVisible(true)                
            }}>Додати</button>
          
          </form>
          
      );
}
 
export default CreateItem;