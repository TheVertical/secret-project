import React, { Children } from 'react';
import "./Main.css"
import Carousel from 'react-bootstrap/Carousel'
import firstSlide from '../../Images/firstSlide.jpg'
import secondSlide from '../../Images/secondSlide.jpg'
import Catalog_Gigiena_I_Profilaktika from '../../pages/Catalog_Gigiena_I_Profilaktika'


class Main extends React.Component{
render(){
    return (
        <div className="mainStyle">
            {/* <div>
                <Carousel>
                    <Carousel.Item interval={1000}>
                        <img
                            className="d-block w-100"
                            src={firstSlide}
                            alt="First slide"
                        />
                        
                    </Carousel.Item>
                    <Carousel.Item interval={1500}>
                        <img
                            className="d-block w-100"
                            src={secondSlide}
                            alt="Secons slide"
                        />
                    </Carousel.Item>
                   
                </Carousel>
            </div> */}
          <Catalog_Gigiena_I_Profilaktika></Catalog_Gigiena_I_Profilaktika>
        </div>
       

    )
    }
}
export default Main