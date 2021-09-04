import React from 'react';
import Header from './header';
import Toolbar from './toolbar';
import { Switch, Route, BrowserRouter as Router } from "react-router-dom";
import Toaster from "./toaster";
import CategoryPage from '../pages/category-page';
import LayoutModals from './layout-modals';

//TODO: Only on develop!
import MockService from '@/shared/mock-service';

const Layout: React.FC = () => {
    const PhoneNumber: string = '8 (812) 388-4538';
    const WorkTime: string = 'ПН-Чт: 10 : 00 - 18 : 00, Пт: 10 : 00 - 17 : 00';
    return (
        <div className="layout-area">
            <Router>
                <Header
                    PhoneNumber={PhoneNumber}
                    WorkTime={WorkTime}
                />
                <Toolbar />
                <Toaster />
                {/* //MOCK */}
                <Switch>
                    <Route exact path="/">
                    </Route>
                    <Route path="/Catalog/Category">
                        {/* //TODO: Only on develop! */}
                        <CategoryPage {...MockService.getCategory(4)}
                        />
                    </Route>
                </Switch>
            </Router>

            <LayoutModals />
        </div>
    );
}

export default Layout;