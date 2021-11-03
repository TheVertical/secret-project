import ToastItem from '@/models/toast-item';
import React from 'react';
import { connect } from 'react-redux';
import { RootState, AppDispatch } from '../store/store';
import ToastElement from './toaster-parts/toast-element';

interface ReduxStateProps {
    toasts: ToastItem[];
}

interface DispatchProps {
    addToastItem: (toastItem: ToastItem | null) => void,
    deleteToastItem: (toastItem: ToastItem | null) => void
}

type Props = ReduxStateProps & DispatchProps;


const Toaster: React.FC<Props> = (props) => {
    const {
        toasts,
        deleteToastItem
    } = props;

    const toaster = toasts.map(item =>
        <ToastElement key={item.Id}
            toastItem={item}
            deleteToastItem={deleteToastItem} />);
    return (
        <div className="toaster-container">
            {toaster}
        </div>
    );
}

const mapStateToProps = (state: RootState): ReduxStateProps => {
    const toasts = state.toaster.ToastItems;
    return { toasts };
}

const mapDispatchToProps = (dispatch: AppDispatch) => {
    return {
        addToastItem: (toastItem: ToastItem) =>
            dispatch({ type: 'toaster-reducer/addToastItem', payload: toastItem }),
        deleteToastItem: (toastItem: ToastItem) =>
            dispatch({ type: 'toaster-reducer/deleteToastItem', payload: toastItem }),
    }
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(Toaster);
