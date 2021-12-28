import React from 'react';
import Header from './header';
import Toolbar from './toolbar';
import { Switch, Route, BrowserRouter as Router } from "react-router-dom";
import Toaster from "./toaster";
import CategoryPage from '../pages/category-page';
import LayoutModals from './layout-modals';

//TODO: Only on develop!
import MockService from '@/shared/mock-service';
import ProductCard from '../pages/product-card';
import { Container, Row, Col } from 'react-bootstrap';
import Home from '../pages/home';

const Layout: React.FC = () => {
    return (
        <div className="layout-area">
            <Router>
                <Header
                />
                <Toolbar />
                <Toaster />
                {/* //MOCK */}
                <Switch>
                    <Route exact path="/">
                        <Home />
                    </Route>
                    <Route path="/Catalog/Category">
                        {/* //TODO: Only on develop! */}
                        <CategoryPage categoryViewModel={MockService.getCategory(100)}
                        />
                    </Route>
                    <Route path="/Catalog/Product/:id">
                        {/* //TODO: Only on develop! */}
                        <Container>
                            <Row>
                                <Col>
                                    <ProductCard productViewModel={MockService.getProduct()} />
                                </Col>
                            </Row>
                        </Container>
                    </Route>
                </Switch>
            </Router>

            <LayoutModals />
        </div>
    );
}

export default Layout;