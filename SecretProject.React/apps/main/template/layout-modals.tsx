import AuthentificationAccountViewModel from '@/models/Account/authentification-account-view-model';
import RegistrationAccountViewModel from '@/models/Account/registration-account-view-model';
import React from 'react';
import { connect } from 'react-redux';
import AuthorizationModal from '../common-components/authorizatiom-modal';
import registerNewAccount, { sendSignIn } from '../store/authorization/authentification-actions';
import { AppDispatch, RootState } from '../store/store';

interface ReduxStateProps {
    authorizationModal: boolean | null;
}

interface DispatchProps {
    toggleAuthorizationModal: () => void
    sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) => void
    sendSignIn: (authentificationAccountViewModel: AuthentificationAccountViewModel) => void
}

type Props = ReduxStateProps & DispatchProps;

const LayoutModals: React.FC<Props> = (props) => {
    const {
        authorizationModal
    } = props;

    const {
        toggleAuthorizationModal,
        sendRegistration,
        sendSignIn
    } = props;

    return (
        <>
            {authorizationModal &&
                <AuthorizationModal
                    closeModal={toggleAuthorizationModal}
                    sendRegistration={sendRegistration}
                    sendSignIn={sendSignIn} />}
        </>
    );
}

const mapStateToProps = (state: RootState): ReduxStateProps => {
    const {
        authorizationModal
    } = state.layoutModals;

    return { authorizationModal };
}

const mapDispatchToProps = (dispatch: AppDispatch) => {
    return {
        toggleAuthorizationModal: () =>
            dispatch({ type: 'layout-modals/toggleAuthorizationModal' }),
        sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) =>
            dispatch(registerNewAccount(registrationAccountViewModel)),
        sendSignIn: (authentificationAccountViewModel: AuthentificationAccountViewModel) =>
            dispatch(sendSignIn(authentificationAccountViewModel)),
    }
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(LayoutModals);
