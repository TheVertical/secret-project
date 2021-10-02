import ShortProductViewModel from '@/models/short-product';
import React from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import CurencyService from '@/shared/curency-service';
import LocalizeService from '@/shared/localization-service';

const ShortProductCard: React.FC<ShortProductViewModel> = (props) => {

    const { 
        Id,
        Name,
        ImageUrl,
        Cost,
        InStock
    } = props;
    return(
        <Card className="d-flex align-content-end">
                <Card.Header>
                    {InStock ?
                    <span className="in-stock">{LocalizeService.localize("InStock")}</span>
                    :
                    <span className="not-in-stock">{LocalizeService.localize("Not_InStock")}</span>
                    }
                </Card.Header>
            <Row>
                <Col className="d-flex justify-content-center">
                    <Card.Img variant="top" src={ImageUrl}/>
                </Col>
            </Row>
            <Card.Body className="p-0">
                <div className="card-name">{Name}</div>
            </Card.Body>
            <Card.Footer className="d-flex">
                <span className="cost discounted-cost">{CurencyService.toRubles(Cost)}</span>
                &emsp;
                <span className="cost real-cost">{CurencyService.toRubles(Cost+500)}</span>
            </Card.Footer>
        </Card>
    );
}

export default ShortProductCard;