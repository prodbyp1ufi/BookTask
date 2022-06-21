import React, {useState} from 'react'
import LoginProvider from '../providers/loginProvider'

export default function Login({setAuth}){

    const [login, setLogin] = useState()
    const [password, setPassword] = useState()

    function auth(){
        LoginProvider.getToken(login,password).then(result=>{
            setAuth(localStorage.getItem('testTaskBookToken') !== null)
        })
        
    }


    return(
    <div className='login-container'>
        <label>Логин</label>
        <input onChange={(e)=>{setLogin(e.target.value)}} type="text" />
        <label>Пароль</label>
        <input type="password" onChange={(e)=>{setPassword(e.target.value)}}/>
        <input type="button" onClick={()=>{auth()}} value="Войти"/>
    </div>
)

}