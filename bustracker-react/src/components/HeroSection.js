function HeroSection({ title, content, heroClass }) {
    return (
      <section className={`hero-section ${heroClass}`}>
        <div className="container d-flex align-items-center justify-content-center fs-1 text-white flex-column">
          <h1>{title}</h1>
          {content}
        </div>
      </section>
    );
  }

  export default HeroSection