import React, { FunctionComponent as FC} from 'react';
import ContactForm from './ContactForm';

interface HeaderInfo {
    PhoneNumber: string,
    WorkTime: string
}

const Header: React.FC<HeaderInfo> = (props) => {

    const { PhoneNumber, WorkTime }= props;
    return(
        <div className='header'>
            <div className='container'>
                <div className='col-md-4'>
                    <img src='./Images/Logo.png' alt='Olimp-dental'/>
                </div>
                <div className="col-md-5">
                    <a href="">
                        // TODO: localize
                        'Header_DeliveryAndPayment'
                    </a>
                    <a href="">
                        // TODO: localize
                        'Header_Return'
                    </a>
                    <a href="">
                        // TODO: localize
                        'Header_PickUPoint'
                    </a>
                    <a href="">
                        // TODO: localize
                        'Header_News'
                    </a>
                    <a href="">
                        // TODO: localize
                        'Header_PromotionsAndDiscounts'
                    </a>
                    <a href="">
                        // TODO: localize
                        'Header_Reviews'
                    </a>
                </div>
                <div className="col-md-3">
                    <div className="contact-form">
                        <ContactForm 
                            PhoneNumber={PhoneNumber}
                            WorkTime={WorkTime}
                            ShowBackCall={true}/>
                    </div>
                </div>
            </div>
        </div>
    );

}

export default Header;