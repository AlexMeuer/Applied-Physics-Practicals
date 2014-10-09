#pragma once
#include "Ogre.h"

class PhysicsObject{
	private:
		Ogre::Vector3 m_position; // position
		Ogre::Vector3 m_velocity;  // velocity
		Ogre::Vector3 m_accel; // accelaration
		double m_radius;			// radius of sphere
		Ogre::SceneNode *m_objectNode;//graphics node of model
		bool m_move;			// moving or not
		float m_angle;
		float m_power;
		float m_airtime;	//in seconds
		float m_maxHeight;
		//float m_xDisplacement;

		float g, m, Ca;

public:
	PhysicsObject(void); // constructor
	~PhysicsObject(void); // destructor

	Ogre::Vector3 getPosition();// returns m_position
	Ogre::Vector3 getVelocity();//returns m_velocity
	Ogre::Vector3 getAccel();
	float getAngle();
	float getPower();
	Ogre::SceneNode* getNode();//returns SceneNode pointer

	double getRadius();  // returns m_radius
	bool getMove();  // returns m_move

	void setPosition(Ogre::Vector3);// sets m_position
	void setVelocity(Ogre::Vector3);//sets m_velocity
	void setAngle(float);
	void setPower(float);
	void setCa(float);
	void setMove(bool);  // sets m_move
	void initialise(Ogre::SceneNode* , double, Ogre::Vector3, Ogre::Vector3, float, float);
	void update(double elapsedTime);
	float getAirtime() const;
	float getMaxHeight() const;
	void reset();
	//float getXDisplacement() const;


};
