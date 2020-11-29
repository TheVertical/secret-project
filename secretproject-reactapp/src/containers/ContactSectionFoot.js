import React from "react"
import "./ContactSectionFoot.css"
import ContactSection from "./../basedComponents/ContactSection"
import Picture from "./../basedComponents/Picture"
import logo from "./../Images/LogoDown.png"
// Здесь будут состояния



//Здесь будут функции(внешние)


//Здесь будет главная функция экспорта 
const ContactSectionFoot = (props) => {
   

    return (

        <div className="blockStylle">
            <Picture src={logo}></Picture>
            <a href="tel:88123884538" className="bigAAStyle">8 (812) 388-4538</a>
            <p className="pppStyle">Пн-Чт:10:00-18:00, Пт:10:00-17:00</p>
            
            
        </div>



    )

}





export default ContactSectionFoot