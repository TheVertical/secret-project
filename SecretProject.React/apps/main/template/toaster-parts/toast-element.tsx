import ToastItem from '@/models/toast-item';
import React from 'react';
import { Row, Col, Toast } from 'react-bootstrap';

interface ToastElementProps {
    toastItem: ToastItem,
    deleteToastItem: (toastItem: ToastItem) => void
}
const ToastElement: React.FC<ToastElementProps> = (props) => {
    const { toastItem, deleteToastItem } = props;
    
    return (
        <Row className="d-flex justify-content-end">
            <Col>
                <Toast
                    className="d-inline-block mb-1"
                    animation={true}
                    autohide={true}
                    onClose={() => deleteToastItem(toastItem)}>
                    <Toast.Header closeButton={true} closeLabel="asdfsdf">
                        <svg className="toast-logo mr-2 rounded">
                            <rect className={toastItem.Type} />
                        </svg>
                        <strong className="mr-auto">{toastItem.Title}</strong>
                    </Toast.Header>
                    <Toast.Body>{toastItem.Message}</Toast.Body>
                </Toast>
            </Col>
        </Row>
    );
}

export default ToastElement;