function SidebarDropdown({id, target, icon, label, children}) {
    return (
        <li className="sidebar-item">
            <a href="#" className="sidebar-link collapsed has-dropdown" data-bs-toggle="collapse"
               data-bs-target={`#${target}`} aria-expanded="false" aria-controls={target}>
                <i className={`lni ${icon}`}></i>
                <span>{label}</span>
            </a>
            <ul id={id} className="sidebar-dropdown list-unstyled collapse" data-bs-parent="#sidebar">
                {children}
            </ul>
        </li>
    );
}

export default SidebarDropdown;