import React, { Children } from 'react';
import "./Main.css"
// import Carousel from 'react-bootstrap/Carousel'
// import firstSlide from '../../Images/firstSlide.jpg'
// import secondSlide from '../../Images/secondSlide.jpg'
import Catalog_Page from '../../pages/Catalog_Page'


class Main extends React.Component{
render(){
    return (
        <div className="mainStyle">
            {/* <div>
                <Carousel>
                    <Carousel.Item interval={1000}>
                        <img
                            className="d-block w-100"
                            src={'./Images/firstSlide.jpg'}
                            alt="First slide"
                        />
                        
                    </Carousel.Item>
                    <Carousel.Item interval={1500}>
                        <img
                            className="d-block w-100"
                            src={'./Images/secondSlide.jpg}
                            alt="Secons slide"
                        />
                    </Carousel.Item>
                   
                </Carousel>
            </div> */}
          <Catalog_Page></Catalog_Page>
        </div>
       

    )
    }
}
export default Main