import React, { FunctionComponent as FC} from 'react';
import ContactForm from '../common-components/contact-form';
import LocalizeService from '@/shared/localization-service'

interface HeaderInfo {
    PhoneNumber: string,
    WorkTime: string
}

const Header: React.FC<HeaderInfo> = (props) => {

    const { PhoneNumber, WorkTime }= props;
    return(
        <div className='header'>
            <div className='container'>
                <div className="row">
                    <div className='col-md-4'>
                        <img src='/Images/Logo.png' alt='Olimp-dental'/>
                    </div>
                    <div className="col-md-5">
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_DeliveryAndPayment')}
                        </div>
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_Return')}
                        </div>
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_PickUPoint')}
                        </div>
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_News')}
                        </div>
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_PromotionsAndDiscounts')}
                        </div>
                        <div className="d-inline-block">
                            {/* // TODO: localize */}
                            {LocalizeService.localize('Header_Reviews')}
                        </div>
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
        </div>
    );

}

export default Header;