import ShortProductViewModel from '@/models/short-product';
import React from 'react';
import { Carousel, CarouselItemProps, Col, Container, Row } from 'react-bootstrap';
import { VisualConstants } from '../constants';
import ShortProductCard from './short-product-card';

interface ShortProductCardCarouselProps {
    shortProducts: ShortProductViewModel[],
    maxShortProductCardCount: number,
}
const ShortProductCardCarousel: React.FC<ShortProductCardCarouselProps> = (props) => {
    const { shortProducts } = props;

    var maxShortProductCardCount = props.maxShortProductCardCount > VisualConstants.Carousel.MaxShortProductCardCount
        ? VisualConstants.Carousel.MaxShortProductCardCount
        :
        props.maxShortProductCardCount;

    if (maxShortProductCardCount > VisualConstants.Carousel.MaxShortProductCardCount) {
        maxShortProductCardCount = VisualConstants.Carousel.MaxShortProductCardCount;
    }

    const renderCarouselItems = function (shortCards: ShortProductViewModel[]): JSX.Element[] {
        const items: JSX.Element[] = [];

        for (let i = 0; i < shortCards.length - 4; i++) {
            var element = (
                <Carousel.Item key={shortCards[i].Id}>
                    <Container>
                        <Row>
                            <Col key={shortCards[i].Id} md={3} className="d-flex justify-content-center">
                                <ShortProductCard shortProductViewModel={shortCards[i]} />
                            </Col>
                            <Col key={shortCards[i + 1].Id} md={3} className="d-flex justify-content-center">
                                <ShortProductCard shortProductViewModel={shortCards[i + 1]} />
                            </Col>
                            <Col key={shortCards[i + 2].Id} md={3} className="d-flex justify-content-center">
                                <ShortProductCard shortProductViewModel={shortCards[i + 2]} />
                            </Col>
                            <Col key={shortCards[i + 3].Id} md={3} className="d-flex justify-content-center">
                                <ShortProductCard shortProductViewModel={shortCards[i + 3]} />
                            </Col>
                        </Row>
                    </Container>
                </Carousel.Item>
            );

            items.push(element);
        }

        return items;
    }

    return (
        <Carousel variant='dark'>
            {renderCarouselItems(shortProducts)}
        </Carousel>
    );
}

export default ShortProductCardCarousel;