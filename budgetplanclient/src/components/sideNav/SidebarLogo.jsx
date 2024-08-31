import {useNavigate} from "react-router-dom";

function SidebarLogo() {
    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    return (
        <div className="sidebar-logo my-2">
            <a href={''} onClick={() => handleClick('/')}>Budżet Plan</a>
        </div>
    );
}

export default SidebarLogo;