import './SideNavigationBar.css';
import { useNavigate } from "react-router-dom";
import {useContext} from 'react';
import {AuthContext} from '../../services/authProvider.jsx';
import UserProfileInfoListItem from "./UserProfileInfoListItem.jsx";

function SideNavigationBar() {
    const {user, login, logout} = useContext(AuthContext);
    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    return (
        <>
            {
                user ? (
                    <>
                        <div className={'top-navbar'}>
                            <div className={'navbar-item'} onClick={() => handleClick('/')}>
                                <a>Pulpit</a>
                            </div>
                            <div className={'navbar-item'} onClick={() => handleClick('/TransactionCategory')}>
                                <a>Kategorie</a>
                            </div>
                        </div>
                        <div className={'bottom-navbar'}>
                            <div className={'navbar-item'} onClick={logout}>
                                <a>Wyloguj</a>
                            </div>
                            <UserProfileInfoListItem/>
                        </div>
                    </>
                ) : (
                    <div className={'bottom-navbar'}>
                        <div className={'navbar-item'} onClick={login}>
                            <a>
                                Zaloguj
                            </a>
                        </div>
                    </div>
                )
            }
        </>
    );
}

export default SideNavigationBar;