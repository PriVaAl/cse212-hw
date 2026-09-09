public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] Features {get; set;}
    public class Feature
    {
        public Epicenter Properties {get; set ;}
    }
    public class Epicenter
    {
        public string Place {get; set ;}
        public double Mag {get; set;}
    }

    
} 