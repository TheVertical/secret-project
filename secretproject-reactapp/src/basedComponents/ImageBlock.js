import React from "react"
import {NavLink} from "react-router-dom"
// Здесь будут состояния



//Здесь будут функции(внешние)




//Здесь будет главная функция экспорта 
const picture=(props)=>{

    //Здесь будут функции(внутренние)

return(
<NavLink to={props.Links}>
 <img src={props.src}></img>
</NavLink>

);

}



export default picture
