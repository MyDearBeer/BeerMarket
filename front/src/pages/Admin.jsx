import React,{useState} from 'react'
import CreateItem from '../components/modals/CreateItem';

import Modal from '../components/modals/Modal';
import { createFactories, createTypes } from '../http/ItemAPI';
import './Admin.css'


const Admin = () => {

  const[modalTypeVisible,setModalTypeVisible] = useState(false)
  const[modalFactoryVisible,setModalFactoryVisible] = useState(false)
  const[modalItemVisible,setModalItemVisible] = useState(false)
  const[type,setType] = useState()
  const[factory,setFactory] = useState()

  const addType=()=>    {
createTypes({name:type}).then(data=>setType(''))
setModalTypeVisible(false)
  }
  const addFactory=()=>    {
    createFactories({name:factory}).then(data=>setFactory(''))
    setModalFactoryVisible(false)
      }
    

  return (
      <div className='admin'>
        <div className='postbuttons'>
         
         <button className='postbutton' onClick={()=>setModalTypeVisible(true)}>Додати тип товару</button>  
         <button className='postbutton' onClick={()=>setModalFactoryVisible(true)}>Додати виробника</button>  
         <button className='postbutton' onClick={()=>setModalItemVisible(true)}>Додати товар</button> 
         <Modal  active={modalTypeVisible} setActive={setModalTypeVisible}>
          <form>
            <h1>Введіть назву категорії</h1>
            <input type="text" value={type} onChange={e=>setType(e.target.value)}/>
          {type?
           <button className='addbtn' onClick={ (e)=>{
          e.preventDefault()
          addType()}}>Add</button>
        :   <button className='addbtn' disabled>Add</button>}
           
          </form>
            </Modal>
            <Modal active={modalFactoryVisible} setActive={setModalFactoryVisible}>
          <form>
            <h1>Введіть назву виробника</h1>
            <input type="text" value={factory} onChange={e=>setFactory(e.target.value)}/>
            <h1>Введіть адресу виробника</h1>
            <input type="text"/>
            <button className='addbtn' onClick={(e)=>{
             e.preventDefault()
             addFactory()}}>Add</button>
          </form>
            </Modal>
{/* 
            <Modal active={modalItemVisible} setActive={setModalItemVisible}>
          <form>
            <h1>Введіть назву виробу</h1>
            <input type="text"/>
            <h1>Введіть ціну за 1 од.</h1>
            <input type="text"/>
            <h1>Введіть ціну за 1 од.</h1>
            <input type="text"/>
            <button className='addbtn' onClick={()=>setModalItemVisible(false)}>Add</button>
          </form>
            </Modal> */}
<Modal active={modalItemVisible} setActive={setModalItemVisible}>
            <CreateItem setActive={setModalItemVisible}/>
            </Modal>
        </div>
        </div>
      );
}
 
export default Admin;