import RegistrationAccountViewModel from '@/models/registration-account-view-model';
import React from 'react';
import { connect } from 'react-redux';
import AuthorizationModal from '../common-components/authorizatiom-modal';
import { AppDispatch, RootState } from '../store/store';

interface ReduxStateProps {
    authorizationModal: boolean | null;
}

interface DispatchProps {
    toggleAuthorizationModal: () => void
    sendRegistration: (registrationAccountViewModel: RegistrationAccountViewModel) => void
}

type Props = ReduxStateProps & DispatchProps;

const LayoutModals: React.FC<Props> = (props) => {
    const {
        authorizationModal
    } = props;

    const {
        toggleAuthorizationModal,
        sendRegistration
    } = props;

    return (
        <>
            {authorizationModal &&
                <AuthorizationModal
                    closeModal={toggleAuthorizationModal}
                    sendRegistration={sendRegistration} />}
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
            dispatch({ type: 'authorization-reducer/registerNewAccount', payload: registrationAccountViewModel }),
    }
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(LayoutModals);
