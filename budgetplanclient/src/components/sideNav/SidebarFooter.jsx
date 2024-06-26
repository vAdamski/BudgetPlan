import {useContext} from "react";
import {AuthContext} from "../../services/authProvider.jsx";

function SidebarFooter() {
    const {user, login, logout} = useContext(AuthContext);

    const userName = user && user.profile ? user.profile.name : '';


    return (
        <>
            {user ?
                (
                    <div className="sidebar-footer">
                        <a className="sidebar-link">
                            <i className="lni lni-user"></i>
                            <span>Witaj {userName}!</span>
                        </a>
                        <a className="sidebar-link" onClick={logout}>
                            <i className="lni lni-exit"></i>
                            <span>Wyloguj się</span>
                        </a>
                    </div>
                )
                :
                (
                    <div className="sidebar-footer">
                        <a className="sidebar-link" onClick={login}>
                            <i className="lni lni-enter"></i>
                            <span>Zaloguj się</span>
                        </a>
                    </div>
                )
            }
        </>

    );
}

export default SidebarFooter;