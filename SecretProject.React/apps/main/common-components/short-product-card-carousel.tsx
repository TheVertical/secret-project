import ShortProductViewModel from '@/models/short-product';
import classNames from "classnames";
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

        const renderCarouselItemsIternal = function (index: number, take: number, count: number) {
            const items = [];

            while (index < count && take > 0) {
                items.push(
                    <Col key={shortCards[index].Id} md={3} className="d-flex justify-content-center">
                        <ShortProductCard shortProductViewModel={shortCards[index]} />
                    </Col>
                );
                index++;
                take--;
            }

            return items;
        }


        for (let i = 0; i < shortCards.length - maxShortProductCardCount; i++) {
            var element = (
                <Carousel.Item key={shortCards[i].Id}>
                    <Container>
                        <Row className="justify-content-around">
                            {renderCarouselItemsIternal(i, maxShortProductCardCount, shortCards.length)}
                        </Row>
                    </Container>
                </Carousel.Item>
            );

            items.push(element);
        }

        return items;
    }

    return (
        // @ts-ignore
        <Carousel variant='blue' slide={false} className="short-product-card-carousel">
            {renderCarouselItems(shortProducts)}
        </Carousel>
    );
}

export default ShortProductCardCarousel;