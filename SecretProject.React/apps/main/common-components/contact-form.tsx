import React, { FunctionComponent as FC} from 'react';
import LocalizeService from '@/shared/localization-service'

interface ContactViewModel {
    PhoneNumber: string,
    WorkTime: string,
    ShowCallback: boolean,
}

const ContactForm: React.FC<ContactViewModel> = (props) => {
const { PhoneNumber, WorkTime, ShowCallback } = props;
    return(
        <div className="contact-form">
            <div className="phone-number phone-number-white text-md-center">
                {PhoneNumber}
            </div>
            <div className="work-time text-md-center">
                {WorkTime}
            </div>
            {ShowCallback ? 
            <div className="request-callback-white text-md-center">
                {LocalizeService.localize("ContactForm_RequestCallBack")}
            </div>
            : undefined
            }
        </div>
    );
}

export default ContactForm;