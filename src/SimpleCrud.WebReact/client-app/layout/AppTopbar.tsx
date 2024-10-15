import React, { forwardRef} from 'react';
import { AppTopbarRef } from '@/types';

const AppTopbar = forwardRef<AppTopbarRef>(() => {
    return (
        <div className="layout-topbar">
            <span>SIMPLE CRUD</span>
        </div>
    );
});

AppTopbar.displayName = 'AppTopbar';

export default AppTopbar;
