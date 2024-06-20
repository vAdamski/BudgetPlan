import './HomePage.css';
import {useContext} from 'react';
import {AuthContext} from '../../../services/authProvider.jsx';

const HomePage = () => {
    const {user,} = useContext(AuthContext);

    return (
        <div className={''}>
            <h1>Home Page</h1>
            <h3>JWT Token</h3>
            <p style={{
                wordWrap: 'break-word',
            }}>{user ? user.access_token : 'User not authenticated'}</p>
        </div>
    );
};

export default HomePage;