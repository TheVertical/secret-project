import ShortProductViewModel from '@/models/short-product';
import MockService from '@/shared/mock-service';
import React from 'react';
import { Carousel, Container, Row } from 'react-bootstrap';
import { connect } from 'react-redux';
import ShortProductCardCarousel from '../common-components/short-product-card-carousel';
import { RootState, AppDispatch } from '../store/store';

interface ReduxStateProps {
    bannerProducts: ShortProductViewModel[],
    specialOfferProducts: ShortProductViewModel[],
    bestsellerProducts: ShortProductViewModel[],
}

interface DispatchProps {

}

type Props = ReduxStateProps & DispatchProps;

const Home: React.FC<Props> = (props) => {

    const {
        bannerProducts, specialOfferProducts, bestsellerProducts
    } = props;


    return (
        <div className="home-page">
            <Container>
                <Row>
                    <ShortProductCardCarousel shortProducts={specialOfferProducts} maxShortProductCardCount={4} />
                </Row>
            </Container>
        </div>
    );
}

const mapStateToProps = (state: RootState): ReduxStateProps => {
    var c: ReduxStateProps = {
        bannerProducts: MockService.Visual.getBanners(5),
        specialOfferProducts: MockService.getShortProducts(6),
        bestsellerProducts: MockService.getShortProducts(6)
    }
    return c;
}

const mapDispatchToProps = (dispatch: AppDispatch) => {
    return {

    };
}

export default connect<ReduxStateProps, DispatchProps>(mapStateToProps, mapDispatchToProps)(Home);