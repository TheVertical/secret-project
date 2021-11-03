import React, { FunctionComponent as FC} from 'react';
import LocalizeService from '@/shared/localization-service'

interface ContactFormProps {
    phoneNumber: string,
    workTime: string,
    showCallback: boolean,
}

const ContactForm: React.FC<ContactFormProps> = (props) => {
const { phoneNumber, workTime, showCallback } = props;
    return(
        <div className="contact-form">
            <div className="phone-number phone-number-white text-md-center">
                {phoneNumber}
            </div>
            <div className="work-time text-md-center">
                {workTime}
            </div>
            {showCallback ? 
            <div className="request-callback-white text-md-center">
                {LocalizeService.localize("ContactForm_RequestCallBack")}
            </div>
            : undefined
            }
        </div>
    );
}

export default ContactForm;